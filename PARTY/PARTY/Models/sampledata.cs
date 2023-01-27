using WebApplication1.Model;

namespace WebApplication1.Models
{
    public static class sampledata
    {
        private static List <Party> friends= new List <Party>()
        {
            new Party(){name="MOHAMED" ,email="mohamed@gmail.com", phone=0111111 ,attend="yes"},
             new Party(){name="ahmed" ,email="ahmed@gmail.com", phone=0111111 ,attend="no"},
        };
        public static List <Party> Friends { get => friends; }

        public static void add(Party p)
        {
            friends.Add(p); 

        }
    }
}
