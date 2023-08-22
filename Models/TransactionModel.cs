namespace MySql_Minimal_Api_Project.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string TransactionCode { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
        public int InitiatorId { get; set; }
        public int RecipientId { get; set; }



    }
}
