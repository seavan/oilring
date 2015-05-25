	
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
      public void CheckVisit(long _userId, string _userType, ICommentable _item)
       {
           CreateRelation<_CommentableVisitLink>( new DummyEntity(_userId, _userType), _item, s =>
                                                                                                  {
                                                                                                      s.LastCommentCount
                                                                                                          =
                                                                                                          _item.
                                                                                                              AUTO_CommentCount;
                                                                                                      s.PreviousVisitDateTime =
                                                                                                          s.LastVisitDateTime;
                                                                                                      s.LastVisitDateTime = DateTime.Now;
                                                                                                      return s;

                                                                                                  });
              
       }
    }
}	
