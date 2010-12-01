using System;



namespace WebUi.ViewModels
{
    public class VotingInfo
    {
        public string ReturnUrl { get; set; }
        public Int64? ProductId { get; set; }
        public Int64? UserName { get; set; }
        public string VoteValue { get; set; }
    }
}