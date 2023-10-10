import React, { useEffect, useState } from "react";
import "../styles/post.css";
import 'bootstrap-icons/font/bootstrap-icons.css';
import axios from 'axios';

const Post = (props) => {
  
  const initialNote = {
    name: "",
    text: "",
    author: "",
    sectionId: 0,
    roomId: 0,
    postId: "",
    id: 0,
    creationDate: new Date(),
    lastUpdatedDate: new Date(),
  };
  
  const [liked, setLiked] = useState(false);
  const [disliked, setDisliked] = useState(false);
  const [note, setNote] = useState(initialNote);
  const [post, setPost] = useState(props.post);
  
  const fetchNote = () => {
    axios.get(`/v1/notes/${props.noteId}`)
      .then(response => setNote(response.data))
  }
  
  const handleDelete = (postId) => {
    props.setPosts((prevPosts) => prevPosts.filter((x) => x.postId !== postId));
    axios.delete(`/v1/posts?postId=${postId}`)
      .then();
  }
  
  const updatePost = () => {
    axios.put(`/v1/posts?postId=${props.postId}`, post)
      .then();
  }
  
  useEffect(() => {
    fetchNote();
  }, []);
  
  useEffect(() => {
    updatePost();
  }, [post.likeCount, post.dislikeCount]);

  const updateCounts = (propertyToUpdate, incrementBy) => {
    setPost((prevPost) => ({
      ...prevPost,
      [propertyToUpdate]: prevPost[propertyToUpdate] + incrementBy
    }));
  }
  
  const handleLike = () => {
    if(disliked) {
      setDisliked(!disliked);
      updateCounts("dislikeCount", -1);
    }
    
    if(!liked) {
      updateCounts("likeCount", 1);
    } else {
      updateCounts("likeCount", -1)
    }
    setLiked(!liked);
  }

  const handleDislike = () => {
    if(liked) {
      setLiked(!liked);
      updateCounts("likeCount", -1);
    }

    if(!disliked) {
      updateCounts("dislikeCount", 1);
    } else {
      updateCounts("dislikeCount", -1)
    }
    setDisliked(!disliked);
  }
  
  return(
    <div className="card post">
      <div className="card-body">
        <div className="content-placement">
          <div>
            <h5 className="card-title post-title">{props.title}</h5>
            <div className="card-text note">
              {note.text}
            </div>
          </div>
          <div>
            <button className="buttons delete-button" onClick={() => handleDelete(props.postId)}>
              <i className="bi bi-trash3 delete-icon"></i>
            </button>
            <button className="buttons edit-button">
              <i className="bi bi-pen edit-icon"></i>
            </button>
          </div>
        </div>
        <p>
          <button className="reaction-buttons" onClick={handleLike}>
            {post.likeCount} {liked ? <i className="bi bi-hand-thumbs-up-fill"></i> : <i className="bi bi-hand-thumbs-up "></i>}
          </button>
          <button className="reaction-buttons" onClick={handleDislike}>
            {post.dislikeCount} {disliked ? <i className="bi bi-hand-thumbs-down-fill"></i> : <i className="bi bi-hand-thumbs-down"></i>}
          </button>
        </p>
      </div>
    </div>
  );
}

export default Post;