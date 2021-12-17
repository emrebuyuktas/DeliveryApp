using System;

namespace DeliveryApp.Core.Dtos
{
    public class CommentDto
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int ProductId { get; set; }
    }
}
