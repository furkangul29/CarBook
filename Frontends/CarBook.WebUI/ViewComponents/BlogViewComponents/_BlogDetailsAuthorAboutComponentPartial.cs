using CarBook.Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public _BlogDetailsAuthorAboutComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7292/api/Blogs/GetBlogByAuthorId/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAuthorByBlogAuthorIdDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
