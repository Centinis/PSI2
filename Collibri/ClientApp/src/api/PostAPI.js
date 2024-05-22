import axios from 'axios';

export const createPost = (post, setPosts, addNewPost) => {

    return fetch('/v1/posts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: post
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to create post');
            }
            return response.json();
        })
        .then(data => {
            console.log('Post created successfully:', data);
            setPosts(prevPosts => [...prevPosts, data]);
            addNewPost(data);
            return data;
        })
        .catch(error => {
            console.error('Error creating post:', error.message);
        });
}

export const fetchPosts = (sectionId, setPosts) => {
  axios.get(`/v1/posts?sectionId=${sectionId}`)
    .then(response => setPosts(response.data))
    .catch(error => {
      console.log(error.message);
    })
}

export const deletePost = (postId) => {
  return axios.delete(`/v1/posts?postId=${postId}`)
    .then(response => {
      if(response.data) {
        return response.data;
      } else {
        throw new Error("Unsuccessful request to delete.");
      }
    })
}

export const updatePost = (postId, postToUpdate) => {
  axios.put(`/v1/posts?postId=${postId}`, postToUpdate)
    .then()
    .catch(error => console.error('Error updating post: ', error))
}
