using DigiArticle.Entity.Interfaces;
using System;

namespace DigiArticle.Entity.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}