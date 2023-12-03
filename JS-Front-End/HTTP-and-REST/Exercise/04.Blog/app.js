let posts;

function attachEvents() {
  document.querySelector("#btnLoadPosts").addEventListener("click", loadPosts);
  document
    .querySelector("#btnViewPost")
    .addEventListener("click", loadSinglePost);
}

async function loadSinglePost() {
  const result = await (
    await fetch("http://localhost:3030/jsonstore/blog/comments")
  ).json();

  const selectedPost = posts[document.querySelector("#posts").value];
  const comments = Object.values(result).filter(
    (comment) => comment.postId === selectedPost.id
  );
}

async function loadPosts() {
  const result = await (
    await fetch("http://localhost:3030/jsonstore/blog/posts")
  ).json();

  posts = result;

  const postsDropdown = document.querySelector("#posts");

  Object.values(result).forEach((post) => {
    const option = document.createElement("option");
    option.value = post.id;
    option.text = post.title;

    postsDropdown.appendChild(option);
  });
}

attachEvents();
