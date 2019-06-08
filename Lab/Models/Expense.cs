﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labo2.Models
{
    public enum Type
    {
        Utilities,
        Food,
        Transportation,
        Outing,
        Groceries,
        Clothes,
        Electronics,
        Other
    }
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [EnumDataType(typeof(Type))]
        public Type Type { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public double Sum { get; set; }
        public List<Comment> Comments { get; set; }
        public User AddedBy { get; set; }

    }
}
