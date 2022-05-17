using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Scala.Dapper1.Core.Entities
{
    [Table("Personen")]
    public class Persoon
    {
        [ExplicitKey]
        public string Id { get; private set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Adres { get; set; }
        public string Gemeente { get; set; }
        public string Land { get; set; }
        public string Telefoon { get; set; }
        public string Email { get; set; }

        public Persoon()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Persoon(string naam, string voornaam, string adres,
            string gemeente, string land, string telefoon, string email)
        {
            Naam = naam;
            Voornaam = voornaam;
            Adres = adres;
            Gemeente = gemeente;
            Land = land;
            Telefoon = telefoon;
            Email = email;
        }
        internal Persoon(string id, string naam, string voornaam, string adres,
            string gemeente, string land, string telefoon, string email)
        {
            Id = id;
            Naam = naam;
            Voornaam = voornaam;
            Adres = adres;
            Gemeente = gemeente;
            Land = land;
            Telefoon = telefoon;
            Email = email;
        }
        public override string ToString()
        {
            return $"{Naam} {Voornaam}";
        }
    }
}
