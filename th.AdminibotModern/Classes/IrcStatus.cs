namespace th.AdminibotModern.Classes
{
    class IrcStatus
    {
        public Types.StatusLevel State { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
