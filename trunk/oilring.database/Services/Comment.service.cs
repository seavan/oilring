	
/*
	Services code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Comment
	File name: 	Comment.service.cs
*/
		

  using System;
  using System.Linq;
  using System.Data.Linq;
  using System.ComponentModel.DataAnnotations;
  using Notamedia.Oilring.Database;
  using System.Collections.Generic;
  using Notamedia.Oilring.Database.DataAccess;
using Database.Implementation;
using Database.Entities;
  namespace admin.db
  {
  public partial class CommentService : DataService<Comment, CommentObject, CommentObject.Converter>, ICommentService
    {
      public override IEnumerable<IDatabaseEntity> UpdateParentAssociations(DataContext s, long _id)
      {
          var res = new List<IDatabaseEntity>();
          var thisObj = s.GetTable<Comment>().Single( obj => obj.Id.Equals(_id) );
        
            if( thisObj.Article != null )
              {
                //var convArticle = ArticleObject.Converter.FULL_CONVERT;
                //res.Add(convArticle(thisObj.Article));

                res.Add(thisObj.Article);
            }

          
            if( thisObj.Conference != null )
              {
                //var convConference = ConferenceObject.Converter.FULL_CONVERT;
                //res.Add(convConference(thisObj.Conference));

                res.Add(thisObj.Conference);
            }

          
            if( thisObj.Discussion != null )
              {
                //var convDiscussion = DiscussionObject.Converter.FULL_CONVERT;
                //res.Add(convDiscussion(thisObj.Discussion));

                res.Add(thisObj.Discussion);
            }

          
            if( thisObj.Event != null )
              {
                //var convEvent = EventObject.Converter.FULL_CONVERT;
                //res.Add(convEvent(thisObj.Event));

                res.Add(thisObj.Event);
            }

          
            if( thisObj.Grant != null )
              {
                //var convGrant = GrantObject.Converter.FULL_CONVERT;
                //res.Add(convGrant(thisObj.Grant));

                res.Add(thisObj.Grant);
            }

          
            if( thisObj.Journal != null )
              {
                //var convJournal = JournalObject.Converter.FULL_CONVERT;
                //res.Add(convJournal(thisObj.Journal));

                res.Add(thisObj.Journal);
            }

          
            if( thisObj.Seminar != null )
              {
                //var convSeminar = SeminarObject.Converter.FULL_CONVERT;
                //res.Add(convSeminar(thisObj.Seminar));

                res.Add(thisObj.Seminar);
            }

          
            if( thisObj.Techno != null )
              {
                //var convTechno = TechnoObject.Converter.FULL_CONVERT;
                //res.Add(convTechno(thisObj.Techno));

                res.Add(thisObj.Techno);
            }

          
        return res;
      }
    }
}	
