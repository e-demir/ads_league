using Ads_League.Common;

namespace Ads_League.Business
{
    public class BusinessLayer : IBusinessLayer
    {
        public MakeDrawingResponseModel MakeDrawing(MakeDrawingRequestModel request)
        {
            var teams = GetAllTeamsShuffled();
            var groups = CreateGroupsByRequestCount(request.GroupCount);
            var response = new MakeDrawingResponseModel
            {
                Groups = new List<GroupModel>()
            };
            Random random = new();

            while (teams.Any(x => !x.IsSelected))
            {
                foreach (var group in groups)
                {
                    var availableTeams = teams.Where(x => !x.IsSelected && !group.Teams.Any(y => y.Country?.CountryName == y.Country?.CountryName)).ToList();

                    if (availableTeams.Any())
                    {
                        var selectedTeam = availableTeams[random.Next(availableTeams.Count)];
                        selectedTeam.IsSelected = true;
                        group.Teams.Add(selectedTeam);
                    }
                }
            }

            response.Groups = groups;            
            return response;
        }

        private List<TeamModel> GetAllTeamsShuffled()
        {
            return GetTeams().OrderBy(x => Guid.NewGuid()).ToList();
        }

        private List<GroupModel> CreateGroupsByRequestCount(int groupCount)
        {
            return GetEmptyGroups().Take(groupCount).ToList();            
        }

        private static List<TeamModel> GetTeams()
        {
            var teams = new List<TeamModel>
            {
                new TeamModel{TeamName = "Adesso İstanbul", IsSelected= false, Country = new CountryModel{ CountryName = "Türkiye", IsSelected=false}},
                new TeamModel{TeamName = "Adesso Ankara", IsSelected= false, Country = new CountryModel{ CountryName = "Türkiye", IsSelected=false}},
                new TeamModel{TeamName = "Adesso İzmir", IsSelected= false, Country = new CountryModel{ CountryName = "Türkiye", IsSelected=false}},
                new TeamModel{TeamName = "Adesso Antalya", IsSelected= false, Country = new CountryModel{ CountryName = "Türkiye", IsSelected=false}},

                new TeamModel{TeamName = "Adesso Berlin", IsSelected= false, Country = new CountryModel{ CountryName = "Almanya", IsSelected=false}},
                new TeamModel{TeamName = "Adesso Frankfurt", IsSelected= false, Country = new CountryModel{ CountryName = "Almanya", IsSelected=false}},
                new TeamModel{TeamName = "Adesso Münih", IsSelected= false, Country = new CountryModel{ CountryName = "Almanya", IsSelected=false}},
                new TeamModel{TeamName = "Adesso Dortmund", IsSelected= false, Country = new CountryModel{ CountryName = "Almanya", IsSelected=false}},

                 new TeamModel{TeamName = "Adesso Paris,", IsSelected= false, Country = new CountryModel{ CountryName = "Fransa", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Marsilya", IsSelected= false, Country = new CountryModel{ CountryName = "Fransa", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Nice", IsSelected= false, Country = new CountryModel{ CountryName = "Fransa", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Lyon", IsSelected= false, Country = new CountryModel{ CountryName = "Fransa", IsSelected=false}},

                 new TeamModel{TeamName = "Adesso Amsterdam", IsSelected= false, Country = new CountryModel{ CountryName = "Hollanda", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Rotterdam", IsSelected= false, Country = new CountryModel{ CountryName = "Hollanda", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Lahey", IsSelected= false, Country = new CountryModel{ CountryName = "Hollanda", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Eindhoven", IsSelected= false, Country = new CountryModel{ CountryName = "Hollanda", IsSelected=false}},

                 new TeamModel{TeamName = "Adesso Lisbon", IsSelected= false, Country = new CountryModel{ CountryName = "Portekiz", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Porto", IsSelected= false, Country = new CountryModel{ CountryName = "Portekiz", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Braga", IsSelected= false, Country = new CountryModel{ CountryName = "Portekiz", IsSelected=false}},
                 new TeamModel{TeamName = "Adesso Coimbra", IsSelected= false, Country = new CountryModel{ CountryName = "Portekiz", IsSelected=false}},

                  new TeamModel{TeamName = "Adesso Roma", IsSelected= false, Country = new CountryModel{ CountryName = "İtalya", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Milano", IsSelected= false, Country = new CountryModel{ CountryName = "İtalya", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Venedik", IsSelected= false, Country = new CountryModel{ CountryName = "İtalya", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Napoli", IsSelected= false, Country = new CountryModel{ CountryName = "İtalya", IsSelected=false}},

                  new TeamModel{TeamName = "Adesso Sevilla", IsSelected= false, Country = new CountryModel{ CountryName = "İspanya", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Madrid", IsSelected= false, Country = new CountryModel{ CountryName = "İspanya", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Barselona", IsSelected= false, Country = new CountryModel{ CountryName = "İspanya", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Granada", IsSelected= false, Country = new CountryModel{ CountryName = "İspanya", IsSelected=false}},

                  new TeamModel{TeamName = "Adesso Brüksel", IsSelected= false, Country = new CountryModel{ CountryName = "Belçika", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Brugge", IsSelected= false, Country = new CountryModel{ CountryName = "Belçika", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Gent", IsSelected= false, Country = new CountryModel{ CountryName = "Belçika", IsSelected=false}},
                  new TeamModel{TeamName = "Adesso Anvers", IsSelected= false, Country = new CountryModel{ CountryName = "Belçika", IsSelected=false}}
            };

            return teams;

        }

        private static List<GroupModel> GetEmptyGroups()
        {
            var groups = new List<GroupModel>
            {
                new GroupModel{ GroupName = "A", Teams = new List<TeamModel>()},
                new GroupModel{ GroupName = "B", Teams = new List<TeamModel>()},
                new GroupModel{ GroupName = "C", Teams = new List<TeamModel>()},
                new GroupModel{ GroupName = "D", Teams = new List<TeamModel>()},
                new GroupModel{ GroupName = "E", Teams = new List<TeamModel>()},
                new GroupModel{ GroupName = "F", Teams = new List<TeamModel>()},
                new GroupModel{ GroupName = "G", Teams = new List<TeamModel>()},
                new GroupModel{ GroupName = "H", Teams = new List<TeamModel>()},
            };
            return groups;
        }
    }
}

