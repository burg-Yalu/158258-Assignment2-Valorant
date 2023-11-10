using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Ass2_Valorant.Models;
using PagedList;
using WebApplication4.Data;

namespace WebApplication4.Controllers
{
    public class PlayersController : Controller
    {
        private WebApplication4Context db = new WebApplication4Context();


        // GET: Players
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            // 始终在数据库中进行排序
            var players = db.Players.OrderBy(p => p.ID).ToPagedList(pageNumber, pageSize);

            return View(players);
        }
        public ActionResult FilterByNation(string nation, int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            // 如果未选择国家或选择的国家为 "All Nations"，则显示所有球员，并按默认顺序排序
            if (string.IsNullOrEmpty(nation) || nation.Contains("All Nations"))
            {
                var allPlayers = db.Players.OrderBy(p => p.ID); // 使用默认排序字段（假设有一个名为Id的字段）
                var pagedPlayers = allPlayers.ToPagedList(pageNumber, pageSize);
                return View("Index", pagedPlayers);
            }
            else
            {
                // 筛选所选国家的球员，并按默认顺序排序
                var filteredPlayers = db.Players
                    .Where(p => p.Region.Nation == nation)
                    .OrderBy(p => p.ID); // 使用默认排序字段

                var pagedPlayers = filteredPlayers.ToPagedList(pageNumber, pageSize);
                return View("Index", pagedPlayers);
            }
        }
        public ActionResult Search(string searchTerm, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            // 在数据库中执行搜索和排序
            var players = db.Players
                .Where(p => p.ID.Contains(searchTerm) || p.Rank.ToString().Contains(searchTerm))
                .OrderBy(p => p.Rank);

            ViewBag.SearchTerm = searchTerm; // 用于在视图中显示搜索条件

            var pagedPlayers = players.ToPagedList(pageNumber, pageSize);

            return View("Index", pagedPlayers);
        }
        public ActionResult SortByRank(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            // 始终在数据库中进行排序
            var players = db.Players.OrderBy(p => p.Rank).ToPagedList(pageNumber, pageSize);

            return View("Index", players);
        }
    }

    }
