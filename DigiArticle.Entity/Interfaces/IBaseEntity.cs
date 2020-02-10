using System;

namespace DigiArticle.Entity.Interfaces
{
    interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreationDate { get; set; }
    }
}
