using E_Tickets.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Tickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public double price { get; set; }
        public string imgURL { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationship
        public List<Actor_Movie>Actors_Movies { get; set; }  
        
        //cinema

        public int CinemaId { get; set; }

        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
