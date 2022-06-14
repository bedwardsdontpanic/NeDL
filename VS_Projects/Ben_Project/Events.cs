namespace Ben_Project
{
    public class Events
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public string location { get; set; }

        public Events()
        {

        }

        public Events(decimal id, string name, string location)
        {
            this.id = id;
            this.name = name;
            this.location = location;
        }
    }
}
