using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using api.Models;
using Microsoft.AspNetCore.Cors;
using System;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/posts")]
    public class PostsController
    {
        List<Posts> posts = new List<Posts>{};

        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public IEnumerable<Posts> ListAllPosts()
        {
            HandlePostData Get = new HandlePostData();
            return Get.Get();
        }

        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Posts newPost)
        {
            HandlePostData Post = new HandlePostData();
            Post.Post(newPost);
        }

        // GET: api/id
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Posts ListPostsById(int id)
        {
            HandlePostData GetById = new HandlePostData();
            return GetById.GetById(id);
        }

        // DELETE: api/Delete/id
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            HandlePostData Delete = new HandlePostData();
            Delete.Delete(id);
        }

        // PUT: api/posts/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put([FromBody] Posts value)
        {
            HandlePostData Put = new HandlePostData();
            Put.Put(value);
        }
    }
}