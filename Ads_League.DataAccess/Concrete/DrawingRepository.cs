using Ads_League.Common.Models.Request;
using Ads_League.DataAccess.Entities;

namespace Ads_League.DataAccess
{
    public class DrawingRepository : IDrawingRepository
    {
        private readonly DrawingContext _context;

        public DrawingRepository(DrawingContext context)
        {
            _context = context;
        }

        public void InsertDrawing(InsertDrawingResultRequest request) // gruplar burada
        {
            var drawingEntity = new Drawing();
            drawingEntity.Groups = new List<Group>();
            drawingEntity.DrawerInformation = request.DrawerInformation;
                       
            foreach (var item in request.Groups)
            {
                var groupEntity = new Group();
                groupEntity.GroupName = item.GroupName;
                groupEntity.DrawingId = drawingEntity.Id;                
                groupEntity.Teams = new List<Team>();

                foreach (var team in item.Teams)
                {
                    var teamEntity = new Team();
                    teamEntity.TeamName = team.TeamName;
                    teamEntity.Group = groupEntity;
                    groupEntity.Teams.Add(teamEntity);
                    
                }
                drawingEntity.Groups.Add(groupEntity);
            };

            _context.Drawings.AddAsync(drawingEntity);
            _context.SaveChangesAsync();
        }
    }
}

