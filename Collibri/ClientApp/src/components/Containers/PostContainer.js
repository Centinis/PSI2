import React, { useEffect, useState } from 'react';
import {Box, List, ListItem, Typography} from '@mui/material';
import Post from '../Post';
import {fetchPosts} from "../../api/PostAPI";
import {containerStyle} from "../../styles/PostContainerStyle";

const PostContainer = (props) => {

  useEffect(() => {
    fetchPosts(props.sectionId, props.setPosts);
  }, [props.sectionId]);
  
  if(props.sectionId === 0) {
      return (
          <>
              <Box sx={containerStyle.container}>
                  <Typography variant="h4" sx={containerStyle.message}>
                      No section selected
                  </Typography>
                  <Typography sx={containerStyle.description}>
                      Click on a section to view posts!
                  </Typography>
              </Box>
          </>
      );
  }
  else if (props.posts.length === 0) {
      return (
          <>
              <Box sx={containerStyle.container}>
                  <Typography variant="h4" sx={containerStyle.message}>
                      No posts created
                  </Typography>
                  <Typography sx={containerStyle.description}>
                      Add a post to this section!
                  </Typography>
              </Box>
          </>
      );
  }
  else {
      return (
          <>
              <Box sx={containerStyle.container}>
                  <List>
                      {props.posts.sort((a, b) => (a.likeCount - a.dislikeCount) > (b.likeCount - b.dislikeCount) ? -1 : 1)
                          .map(item => (
                          <ListItem key={item.id}>
                              <Post post={item} {...item} setPosts={props.setPosts}/>
                          </ListItem>
                      ))}
                  </List>
              </Box>
          </>
      );
  }
  
}

export default PostContainer;