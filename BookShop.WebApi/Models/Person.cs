﻿using System;

namespace BookShop.WebApi.Models
{
    /// <summary>
    /// 1.2 - 2
    /// </summary>
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
        
        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// 1.2 - 2
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}