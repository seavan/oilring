
/*
    Services code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	PrivateMessage
    File name: 	PrivateMessage.service.cs
*/


using System;
using System.Linq;
using System.Data.Linq;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using System.Collections.Generic;
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;
using Common;
namespace admin.db
{
    public partial class PrivateMessageService : OilringDataService<PrivateMessage, PrivateMessageObject, PrivateMessageObject.Converter>, IPrivateMessageService
    {
        public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
        {
            var res = new List<IDatabaseEntity>();
            var thisObj = s.GetTable<PrivateMessage>().Single(obj => obj.Id.Equals(_id));

            return res;
        }


        public override void DeleteAllRelation(string _relation, PrivateMessageObject _item)
        {
            
        }

        #region IPrivateMessageService Members

        public PrivateMessageObject CreateThread(long _targetUserId, long _fromUserId, string _subject, string _text)
        {
            // message thread for the target user
            var tut = MakeThreadFor(_targetUserId, _targetUserId, _fromUserId, _subject, _text);
            var fut = MakeThreadFor(_fromUserId, _targetUserId, _fromUserId, _subject, _text);
            tut.REL_Adjoined = fut.Id;
            fut.REL_Adjoined = tut.Id;

            Update(tut);
            Update(fut);

            ReplyTo(fut.Id, _fromUserId, _text);

            return fut;
        }

        #endregion

        private PrivateMessageObject MakeThreadFor(long _ownerUser, long _targetUserId, long _fromUserId, string _subject, string _text)
        {
            var thread = CreateItem();
            thread.REL_Id = _ownerUser;
            thread.REL_ObjectType = "user";
            thread.Owner_User_ID = _ownerUser;
            thread.REL_ReceiverUserId = _targetUserId;
            thread.REL_SenderUserId = _fromUserId;
            thread.AUTO_Subject = _subject;
            thread.AUTO_Text = _text;
            thread.CreationDate = DateTime.Now;
            thread.PublicationDate = DateTime.Now;
            Insert(thread);
            return thread;
        }


        #region IPrivateMessageService Members


        public PrivateMessageObject ReplyTo(long _threadId, long _fromUserId, string _text)
        {
            var existing = GetById(_threadId);
            var adjoined = existing.REL_Adjoined != null ? GetById(existing.REL_Adjoined.Value) : null;

            var newItem = MakeReplyTo(existing.Id, existing.REL_ReceiverUserId, _fromUserId, _text);
            DataServiceLocator.NotificationService.SendPrivateMessageNotification(newItem);

            existing.AUTO_Text = _text;
            //existing.REL_SenderUserId = existing.REL_ReceiverUserId;
            existing.AUTO_Item_Count++;

            Update(existing);

            if (adjoined != null)
            {
                var adjoinedNewItem = MakeReplyTo(adjoined.Id, existing.REL_ReceiverUserId, _fromUserId, _text);
                adjoined.REL_SenderUserId = _fromUserId;
                adjoined.AUTO_Text = _text;
                adjoined.AUTO_Item_Count++;
                Update(adjoined);
            }

            return existing;
        }

        #endregion

        private PrivateMessageItemObject MakeReplyTo(long _threadId, long _targetUserId, long _fromUserId, string _text)
        {
            var pmi = DataServiceLocator.PrivateMessageItemService.CreateItem();
            pmi.REL_ObjectType = Mapper.INST.GetTypeCode<PrivateMessage>();
            pmi.REL_Id = _threadId;
            pmi.Text = _text;
            pmi.REL_SenderUserId = _fromUserId;
            pmi.REL_ReceiverUserId = _targetUserId;
            pmi.Owner_User_ID = _targetUserId;
            DataServiceLocator.PrivateMessageItemService.Insert(pmi);

            return pmi;
        }
    }
}
