// 1D1E18
// 316C44
// 80CB9E
// B9F5D9
// DEFEF5

export const PostModalStyles = {
  modalStyle: {
    position: 'fixed',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: '70%',
    //height: '60%',
    // width: '80rem',
    // height: '38rem',
    border: '3px solid #000',
    borderColor: '#3f5c4b',
    boxShadow: 24,
    borderRadius: 3,
  },

  info: {
    display: 'flex',
    backgroundColor: '#B9F5D9',
    //backgroundColor: '#B9F5D8',
    paddingTop: '3%',
    paddingRight: '3%',
    paddingLeft: '3%',
    paddingBottom: '2%',
    borderTopLeftRadius: 8,
    borderTopRightRadius: 8
  },

  descriptionBox: {
    marginLeft: '4%',
    width: '65%'
  },

  title: {
    wordBreak: 'break',
    width: '45%',
    lineHeight: '90%',
    maxHeight: '7rem',
    overflow: 'hidden',
    marginTop: '2%',
    textAlign: 'center',
  },

  description: {
    wordBreak: 'break-all',
    overflow: 'hidden',
    lineHeight: '120%',
    // minHeight: '3.8rem',
    // maxHeight: '3.8rem',
    marginTop: '1%'
  },

  userAndDateBox: {
    display: 'flex',
    justifyContent: 'space-between',
    marginTop: '1.5rem',
  },

  contentBox: {
    display: 'flex',
    overflowX: 'auto',
  },
  
  contentBoxContainer: {
    backgroundColor: '#72b68d',
    height: '12.9rem'
  },
  
  buttonBox: {
    display: 'flex',
    justifyContent: 'space-between',
    paddingTop: '1.5rem',
    paddingRight: '2rem',
    paddingLeft: '2rem',
    paddingBottom: '1.5rem',
    backgroundColor: '#80CB9E',
    borderBottomLeftRadius: 8,
    borderBottomRightRadius: 8
  },

  closeButton: {
    width: '3rem',
    height: '3rem',
    marginLeft: '1rem',
    color: '#3f5c4b',
    backgroundColor: '#B9F5D9',
    ':hover': {
      color: '#138c37',
      backgroundColor: '#B9F5D9',
    }
  },

  likeButton: {
    color: '#3f5c4b',
    fontSize: '1rem',
    backgroundColor: '#80CB9E',
    borderRadius: 0,
    ':hover': {
      color: '#368758',
      backgroundColor: '#80CB9E',
    }
  },

  dislikeButton: {
    color: '#3f5c4b',
    fontSize: '1rem',
    backgroundColor: '#80CB9E',
    borderRadius: 0,
    ':hover': {
      color: '#9b4949',
      backgroundColor: '#80CB9E',
    }
  },

  reactionButtonIcon: {
    marginLeft: '0.5rem',
    marginBottom: '0.4rem',
  },
  
  likedButtonIcon: {
    marginLeft: '0.5rem',
    marginBottom: '0.4rem',
    color: '#06b43f',
    "@keyframes like-animation": {
      "0%": {
        transform: 'translateY(0) rotate(0deg)',
      },
      "50%": {
        transform: 'translateY(-10px) rotate(-10deg)'
      },
      
    },
    animation: "like-animation 0.2s ease",
  },

  dislikedButtonIcon: {
    marginLeft: '0.5rem',
    marginBottom: '0.4rem',
    color: '#e02626',
    "@keyframes dislike-animation": {
      "0%": {
        transform: 'rotate(0deg)'
      },
      "25%": {
        transform: 'rotate(20deg)'
      },
      "75%": {
        transform: 'rotate(-20deg)'
      },
      "100%": {
        transform: 'rotate(0deg)'
      },
    },
    animation: "dislike-animation 0.2s ease",
  },
  
  addButton: {
    margin: '0.5rem',
    width: '3rem',
    height: '3rem',
    backgroundColor: '#269160',
    color: '#FFFFFF',
    ':hover': {
      backgroundColor: '#21b873',
    },
  },
  
  addIcon: {
    width: '2rem',
    height: '2rem'
  },
  
  list: {
    display: 'flex',
    maxHeight: '13rem',
    //maxWidth: '70rem',
    // minWidth: '70rem',
    overflowX: 'auto',
    '&::-webkit-scrollbar': {
      height: '12px'
    },
    '&::-webkit-scrollbar-track': {
      backgroundColor: '#d3ede1',
      borderRadius: '20px',
    },
    '&::-webkit-scrollbar-thumb': {
      backgroundColor: '#269160',
      border: 2,
      borderColor: '#d3ede1',
      borderRadius: '20px',
      boxShadow: 2,
    },
    '&::-webkit-scrollbar-thumb:hover': {
      backgroundColor: '#21b873'
    }
  },

  tagBox: {
    display: 'flex',
    backgroundColor: '#72b68d',
    boxShadow: 1,
    borderRadius: 2,
    maxWidth: '35rem',
    justifyContent: 'center'
    //minWidth: 300,
  },

  tagChip: {
    boxShadow: 1,
    backgroundColor: '#9bd0ac',
  },
  
  tagList: {
    display: 'flex',
    overflowX: 'auto',
    '&::-webkit-scrollbar': {
      height: '10px'
    },
    '&::-webkit-scrollbar-track': {
      backgroundColor: '#d3ede1',
      borderRadius: '20px',
    },
    '&::-webkit-scrollbar-thumb': {
      backgroundColor: '#269160',
      border: 2,
      borderColor: '#d3ede1',
      borderRadius: '20px',
      boxShadow: 2,
    },
    '&::-webkit-scrollbar-thumb:hover': {
      backgroundColor: '#21b873'
    }
  },
  
  tagListItem: {
    paddingY: 0,
    paddingX: 1
  },
  
  editButton: {
    marginRight: '0rem',
    color: '#3f5c4b',
    backgroundColor: '#80CB9E',
    ':hover': {
      color: '#138c37',
      backgroundColor: '#80CB9E',
    }
  },
  
  deleteButton: {
    marginRight: '1rem' ,
    color: '#3f5c4b',
    backgroundColor: '#80CB9E',
    ':hover': {
      color: '#e50d0d',
      backgroundColor: '#80CB9E',
      "@keyframes delete-hover-anim": {
        "0%, 100%": {
          transform: 'rotate(0deg)',
          color: '#da8011',
        },
        "25%": {
          transform: 'rotate(3deg)'
        },
        "50%": {
          color: '#e50d0d',
        },
        "75%": {
          transform: 'rotate(-3deg)'
        },
      },
      animation: "delete-hover-anim 0.3s ease infinite",
    }
  },
  
  optionButtons: {
    width: '9rem',
    fontSize: '1rem',
    color: '#000000',
    ':hover': {
      backgroundColor: '#5aab79'
    },
    '&.Mui-selected': {
      backgroundColor: '#21b873',
      ':hover': {
        backgroundColor: '#21b873'
      }
    }
  },
  
  optionButtonBox: {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#80CB9E',
    paddingTop: '1rem',
    paddingBottom: '0.5rem',
  },
  
  addButtonBox: {
    display: 'auto',
    width: '5%'
  },
  
  emptyListMessage: {
    color: '#4f6952',
    fontWeight: '700',
    fontFamily: 'cursive',
    display: 'flex', 
    alignItems: 'center', 
    height: '10rem', 
    width: '72rem', 
    justifyContent: 'center',
  }
}