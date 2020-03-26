using GamesCollection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesCollection.ViewModels
{
    public class CompanyGames
    {
        public static IEnumerable<CompanyGames> CreateGamesList(ICollection<Game> developed, ICollection<Game> published)
        {
            var result =
            developed.Select(dg => new CompanyGames()
            {
                GameId = dg.Id,
                Name = dg.Name,
                IsDeveloper = true,
                IsPublisher = false
            }).Union(published.Select(dg => new CompanyGames()
            {
                GameId = dg.Id,
                Name = dg.Name,
                IsDeveloper = false,
                IsPublisher = true
            })).GroupBy(g => g.GameId, (id, gameList) =>
                new CompanyGames()
                {
                    GameId = id,
                    Name = gameList.FirstOrDefault().Name,
                    IsDeveloper = gameList.Count() == 1 ? gameList.FirstOrDefault().IsDeveloper : true,
                    IsPublisher = gameList.Count() == 1 ? gameList.FirstOrDefault().IsPublisher : true,
                }
            );

            return result;
        }

        public int GameId { get; set; }
        [Display(Name = "Game Name")]
        public string Name { get; set; }
        [Display(Name = "Developed")]
        public bool IsDeveloper { get; set; }
        [Display(Name = "Published")]
        public bool IsPublisher { get; set; }
    }
}
