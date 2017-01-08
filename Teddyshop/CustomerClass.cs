namespace Teddyshop
{
   class CustomerClass
    {
        public string CustomerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SSN { get; set; }
        public string Gender { get; set; }
        public string HomeAddress { get; set; }
        public int HomeZipCode { get; set; }



        public void customerClass(string customerNo)
        {
            this.CustomerNo = CustomerNo;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.HomeAddress = HomeAddress;
            this.HomeZipCode = HomeZipCode;
            this.SSN = SSN;

        }


    }
}