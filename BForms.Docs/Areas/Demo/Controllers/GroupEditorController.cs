﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations;
using BForms.Models;
using BForms.Mvc;
using BForms.Utilities;
using BForms.Docs.Areas.Demo.Mock;
using BForms.Docs.Areas.Demo.Models;
using BForms.Docs.Areas.Demo.Helpers;
using BForms.Docs.Controllers;
using BForms.Docs.Areas.Demo.Repositories;
using BForms.Grid;
using RequireJS;
using BForms.Editor;
using BForms.Docs.Resources;

namespace BForms.Docs.Areas.Demo.Controllers
{


    public class GroupEditorController : BaseController
    {
        private readonly ContributorsRepository repo;

        public GroupEditorController()
        {
            repo = new ContributorsRepository(Db);
        }

        //
        // GET: /Demo/UserGroup/
        public ActionResult Index()
        {
            var model = new GroupEditorModel()
            {
                Contributors = new ContributorsInheritExample
                {
                    Grid = repo.ToBsGridViewModel(new BsGridRepositorySettings<ContributorSearchModel>
                    {
                        Page = 1,
                        PageSize = 5
                    }),
                    Search = repo.GetSearchForm(),
                    Order = new ContributorsOrderModel()
                },

                Contributors3 = new BsEditorTabModel<ContributorRowModel, ContributorSearchModel, ContributorNewModel>
                {
                    Grid = repo.ToBsGridViewModel(new BsGridRepositorySettings<ContributorSearchModel>
                    {
                        Page = 1,
                        PageSize = 5
                    }),
                    Search = repo.GetSearchForm(),
                    New = repo.GetNewForm()
                },

                Group1 = new BsEditorGroupModel<ContributorsGroupRowModel, ContributorsRowFormModel>
                {
                    Items = new List<ContributorsGroupRowModel>()
                    {
                        new ContributorsGroupRowModel
                        {
                            Id = 4,
                            Name = "Marius C.",
                            TabId = YesNoValueTypes.Yes,
                            Form = new ContributorsRowFormModel()
                            {
                                Name = "Marius C."
                            }
                        },
                         new ContributorsGroupRowModel
                        {
                            Id = 1,
                            Name = "Stefan P.",
                            TabId = YesNoValueTypes.Yes,
                            Form = new ContributorsRowFormModel()
                            {
                                Name = "Stefan P."
                            }
                        },
                        new ContributorsGroupRowModel
                        {
                            Id = 2,
                            Name = "Ciprian P.",
                            TabId = YesNoValueTypes.Yes,
                            Form = new ContributorsRowFormModel()
                            {
                                Name = "Ciprian P."
                            }
                        }
                    },
                    Form = new ContributorsRowFormModel()
                },

                Group2 = new BsEditorGroupModel<ContributorsGroupRowModel>
                {
                    Items = new List<ContributorsGroupRowModel>()
                    {
                        new ContributorsGroupRowModel
                        {
                            Id = 4,
                            Name = "Marius C.",
                            TabId = YesNoValueTypes.Yes
                        }
                    }
                },
                Form = new GroupFormModel()
            };

            var viewModel = new GroupEditorViewModel
            {
                Editor2 = model
            };

            var options = new
            {
                getTabUrl = Url.Action("GetTab"),
                save = Url.Action("Save"),
                advancedSearchUrl = Url.Action("Search"),
                addUrl = Url.Action("New")
            };

            RequireJsOptions.Add("index", options);

            return View(viewModel);
        }

        public BsJsonResult GetTab(BsEditorRepositorySettings<YesNoValueTypes> settings)
        {
            var msg = string.Empty;
            var status = BsResponseStatus.Success;
            var html = string.Empty;
            var count = 0;

            try
            {
                html = RenderTab(settings, out count);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = BsResponseStatus.ServerError;
            }

            return new BsJsonResult(new
            {
                Count = count,
                Html = html
            }, status, msg);
        }

        public BsJsonResult Save(GroupEditorModel model)
        {
            var errorMessage = "This is how a server error is displayed in group editor";

            return new BsJsonResult(new
            {
                Message = errorMessage
            },BsResponseStatus.ValidationError, "lalalalal");
        }

        public BsJsonResult Search(ContributorSearchModel model)
        {
            var settings = new BsEditorRepositorySettings<YesNoValueTypes>
            {
                Search = model,
                TabId = YesNoValueTypes.Yes
            };
            var count = 0;

            var html = this.RenderTab(settings, out count);

            return new BsJsonResult(new
            {
                Count = count,
                Html = html
            });
        }

        public BsJsonResult New(ContributorNewModel model)
        {
            var status = BsResponseStatus.Success;
            var row = string.Empty;
            var msg = string.Empty;

            try
            {
                if (ModelState.IsValid)
                {
                    var rowModel = repo.Create(model);

                    var groupEditorModel = new GroupEditorModel
                    {
                        Contributors3 = new BsEditorTabModel<ContributorRowModel, ContributorSearchModel, ContributorNewModel>
                        {
                            Grid = new BsGridModel<ContributorRowModel>
                            {
                                Items = new List<ContributorRowModel>
                                {
                                    rowModel
                                }
                            }
                        }
                    };

                    var viewModel = new GroupEditorViewModel()
                    {
                        Editor2 = groupEditorModel
                    };

                    row = this.BsRenderPartialView("_Editors", viewModel);

                }
                else
                {
                    return new BsJsonResult(
                        new Dictionary<string, object> { { "Errors", ModelState.GetErrors() } },
                        BsResponseStatus.ValidationError);
                }
            }
            catch (Exception ex)
            {
                msg = Resource.ServerError;
                status = BsResponseStatus.ServerError;
            }

            return new BsJsonResult(new
            {
                Row = row
            }, status, msg);
        }

        [NonAction]
        public string RenderTab(BsEditorRepositorySettings<YesNoValueTypes> settings, out int count)
        {
            var html = string.Empty;
            count = 0;

            GroupEditorModel model = new GroupEditorModel();

            switch (settings.TabId)
            {
                case YesNoValueTypes.No:

                    var grid2 = repo.ToBsGridViewModel(settings.ToBaseGridRepositorySettings(), out count);
                    model.Contributors2 = new BsEditorTabModel<ContributorRowModel>
                    {
                        Grid = grid2
                    };
                    break;

                case YesNoValueTypes.Yes:

                    var grid1 = repo.ToBsGridViewModel(settings.ToGridRepositorySettings<ContributorSearchModel>(), out count);

                    model.Contributors = new ContributorsInheritExample
                    {
                        Grid = grid1
                    };
                    break;

                case YesNoValueTypes.Both:

                    var grid3 = repo.ToBsGridViewModel(settings.ToGridRepositorySettings<ContributorSearchModel>(), out count);

                    model.Contributors3 = new BsEditorTabModel<ContributorRowModel, ContributorSearchModel, ContributorNewModel>
                    {
                        Grid = grid3
                    };
                    break;
            }

            var viewModel = new GroupEditorViewModel()
            {
                Editor2 = model
            };

            html = this.BsRenderPartialView("_Editors", viewModel);

            return html;
        }
    }
}