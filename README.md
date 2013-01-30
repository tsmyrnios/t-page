#t-page

An ASP.Net MVC Razor pager that never thought it'd be on a boat.

###Usage

- PagerModel.cs: Move this to your Models folder
- PagerModel.cshtml: Move this to your Shared\EditorTemplates folder (create if it doesn't exist)
- pager.js: include this in the project (usually a scripts folder) and ensure this gets added as a script in your HTML on the Views where the pager will display

*The View*

Put the "EditorFor" for the pager inside a form:

    @model PostListModel
    ...
    @using(var form = Html.BeginForm()){
        @Html.EditorFor(m => m.Pager)
    }

*The Model*

Add a Pager property to the model used by the view

    // Post listing with pager
    public class PostListModel
    {
        public PostListModel()
        {
            Posts = new List<PostModel>();
            ...
            Pager = new PagerModel();
        }
    
        public IEnumerable<PostModel> Posts { get; set; }
        ...
        public PagerModel Pager { get; set; }
    }

*The Controller*

You can simply pass the Model used by the view as an argument to the action and the Pager property will be bound automatically

    public class PostController : Controller
    {
        ...
        
        public ActionResult List(PostListModel model)
        {
            // get data based on pager properties
            // - model.StartRowIndex
            // - model.PageSize
            
            // set the total row count after data has been retrieved
            // - model.TotalRowCount
            ...
            return View(model);
        }
    }
    
###Future

A Nuget package is in the works for this... for now, just copy in the code.

###Tribute

This repo pays homage to the works of Adam Sandberg.