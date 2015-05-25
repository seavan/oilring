using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Notamedia.Oilring.Database.DataAccess;
using Notamedia.Oilring.Database;
using Database;
using Database.Entities;
using Database.Extensions;

namespace admin.db.Updaters
{
    public class OilringUpdater : UniversalUpdater
    {
         public override void Update(DataContext _context, IDatabaseEntity _object)
         {
             TryUpdate<ICommentable>(_context, _object, this.UpdateAs);
             TryUpdate<IDefaultPhotoable>(_context, _object, this.UpdateAs);
             TryUpdate<IObjectUserVisitorCountable>(_context, _object, this.UpdateAs);

             this.ResetDepDb(_object.GetType());
         }

         protected void UpdateAs(DataContext _context, IDatabaseEntity _entity, IPublishedItem _object)
         {
             _object.ModificationDate = DateTime.Now;
         }

         protected void UpdateAs(DataContext _context, IDatabaseEntity _entity, IDefaultPhotoable _object)
         {
             var photo =
                 _context.GetTable<Photo>().Where(s => s.REL_Id.Equals(_entity.Id) && s.REL_ObjectType.Equals(_entity.ObjectType)).OrderByDescending(s => s.Id).FirstOrDefault();
             if (photo != null)
             {
                 _object.AUTO_DefaultPhoto_Alt = photo.Title;
                 _object.AUTO_DefaultPhoto_Guid = photo.Guid;
             }
             else
             {
                 _object.AUTO_DefaultPhoto_Alt = null;
                 _object.AUTO_DefaultPhoto_Guid = null;
             }
         }

         protected void UpdateAs(DataContext _context, IDatabaseEntity _entity, ICommentable _object)
         {
             var comments =
                 _context.GetTable<Comment>().Where(s => s.REL_Id.Equals(_entity.Id) && s.REL_ObjectType.Equals(_entity.ObjectType));

             _object.AUTO_CommentCount = comments.Count();
             _object.AUTO_Comment_LastDateTime = _object.AUTO_CommentCount > 0 ?
                 (Nullable<DateTime>)comments.OrderByDescending(s => s.CreationDate).Select(s => s.CreationDate).FirstOrDefault() : null;
         }

         protected void UpdateAs(DataContext _context, IDatabaseEntity _entity, IObjectUserVisitorCountable _object)
         {
             _object.AUTO_ObjectUserVisitorCount = GetManyToManyRelationCount<_ObjectUserVisitorLink>(_context, _entity);
         }

         protected void UpdateAs(IDefaultPhotoable _object)
         {

         }

         protected void TryUpdate<_T>(DataContext _context, IDatabaseEntity _object, Action<DataContext, IDatabaseEntity, _T> _action) where _T : class
         {
             if (typeof(_T).IsInstanceOfType(_object))
             {
                 _action(_context, _object, (_T)_object);
             }
         }
    }
}
