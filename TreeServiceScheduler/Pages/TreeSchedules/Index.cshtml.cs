using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using TreeServiceScheduler.Models;

namespace TreeServiceScheduler.Pages.TreeSchedules
{
    public class IndexModel : PageModel
    {
        private readonly TreeServiceScheduler.Models.warehouseContext _context;

        public string RecordDateSort { get; set; }
        public string PlantingDateSort { get; set; }
        public string AddressSort { get; set; }
        public string ServiceDate1DueSort { get; set; }
        public string LocalitySort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentLocality { get; set; }
        public string CurrentButton { get; set; }

        public IndexModel(TreeServiceScheduler.Models.warehouseContext context)
        {
            _context = context;
        }

        public PaginatedList<TreeSchedule> TreeSchedule { get;set; }
        //public PaginatedList<TreeSchedule> TreeSchedule { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentLocality, string searchLocality, string currentButton,string filterButton,  int? pageIndex)
        {

            //if (sortOrder != null)
            //{
                CurrentSort = sortOrder;
            //}
            CurrentButton = currentButton;
            CurrentLocality = currentLocality;
            // switch the sort around
            //RecordDateSort = string.IsNullOrEmpty(sortOrder) ? "recordDate_desc" : "";
            RecordDateSort = sortOrder == "RecordDate" ? "recorddate_desc" : "RecordDate";

            PlantingDateSort = sortOrder == "PlantingDate" ? "plantingdate_desc":"PlantingDate";

            AddressSort = sortOrder == "Address" ?  "address_desc":"Address";

            if (filterButton != null && searchLocality != null)
            {
                pageIndex = 1;
                CurrentButton = filterButton;
                CurrentLocality = searchLocality;
            }

            if (filterButton != null && searchLocality == null)
            {
                pageIndex = 1;
                CurrentButton = filterButton;
            }

            if (searchLocality != null && filterButton == null)
            {
                pageIndex = 1;
                CurrentLocality = searchLocality;
            }

            

            //if (filterButton != null)
            //{
            //    pageIndex = 1;
            //    CurrentButton = filterButton;
            //    CurrentLocality = currentLocality;
            //}
            //if (searchLocality != null)
            //{
            //    pageIndex = 1;
            //    CurrentLocality = searchLocality;
            //    CurrentButton = currentButton;
            //}
            //else
            //{
            //    CurrentLocality = currentLocality;
            //    CurrentButton = currentButton;
            //}


            IQueryable<TreeSchedule> treeSheduleIQueryable = from s in _context.TreeSchedule select s;


            //filter button or search string?
            if (!string.IsNullOrEmpty(CurrentButton))
            {
                switch (CurrentButton)
                {
                    case "No Planting Date":
                        treeSheduleIQueryable = treeSheduleIQueryable.Where(s =>
                            (string.IsNullOrWhiteSpace(s.PlantingDate.ToString())));
                        break;
                    case "Service Due":
                        treeSheduleIQueryable = treeSheduleIQueryable.Where(s =>
                            ((s.Service1DateDue <= DateTime.Today && string.IsNullOrWhiteSpace(s.Service1DateComplete.ToString())) ||
                             (s.Service2DateDue <= DateTime.Today && string.IsNullOrWhiteSpace(s.Service2DateComplete.ToString())) ||
                             (s.Service3DateDue <= DateTime.Today && string.IsNullOrWhiteSpace(s.Service3DateComplete.ToString())) ||
                             (s.Service4DateDue <= DateTime.Today && string.IsNullOrWhiteSpace(s.Service4DateComplete.ToString())) 
                             //(s.Service5DateDue < DateTime.Today && string.IsNullOrWhiteSpace(s.Service3DateComplete.ToString())) 
                            ));
                        break;
                    //default:
                    //    treeSheduleIQueryable = treeSheduleIQueryable.Where(s => s.Locality.Contains(CurrentLocality));
                    //    break;
                }
            }


            if (!string.IsNullOrEmpty(CurrentLocality))
            {
                treeSheduleIQueryable = treeSheduleIQueryable.Where(s => s.Locality.Contains(CurrentLocality));
            }


            switch (CurrentSort)
            {
                case "RecordDate":
                    treeSheduleIQueryable = treeSheduleIQueryable.OrderBy(s => s.RecordDate);
                    break;
                case "PlantingDate":
                    treeSheduleIQueryable = treeSheduleIQueryable.OrderBy(s => s.PlantingDate);
                    break;
                case "plantingdate_desc":
                    treeSheduleIQueryable = treeSheduleIQueryable.OrderByDescending(s => s.PlantingDate);
                    break;
                case "Address":
                    treeSheduleIQueryable = treeSheduleIQueryable.OrderBy(s => s.Address);
                    break;
                case "address_desc":
                    treeSheduleIQueryable = treeSheduleIQueryable.OrderByDescending(s => s.Address);
                    break;
                default:
                     treeSheduleIQueryable = treeSheduleIQueryable.OrderByDescending(s => s.RecordDate);
                     break;
            }

            int pageSize = 10;
            TreeSchedule = await PaginatedList<TreeSchedule>.CreateAsync(treeSheduleIQueryable.AsNoTracking(), pageIndex ?? 1, pageSize);
            //TreeSchedule = await treeSheduleIQueryable.AsNoTracking().ToListAsync();
        }
    }
}
