export const PostStyle = {
  cardStyle: {
    backgroundColor: '#B9F5D9',
    width: '100%',
    //backgroundColor: '#1D1E18',
    ':hover': {
      boxShadow: 10
    }
  },
  contentBox: {
    display: 'flex',
    flexDirection: 'row',
    minHeight: "3rem",
  },
  title: {
    //color: '#FFFFFF',
    //color: '#DEFEF5',
    //color: '#B9F5D9'
    //color: '#80CB9E'
    color: '#1D1E18',
    fontSize: '250%',
    fontFamily: 'Segoe UI semibold'
  },
  description: {
    color: '#1D1E18',
    fontFamily: 'Segoe UI semibold',
    wordBreak: "break-all",
    overflow: "hidden",
    textOverflow: "ellipsis",
    display: "-webkit-box",
    WebkitLineClamp: "2",
    WebkitBoxOrient: "vertical",
    minWidth: "93%",
    height: '5%',
    lineHeight: "1rem"
  },
  editingBox: {
    display: "flex",
    flexDirection: "column"
  },
  baseEditButton: {
    color: '#316C44',
    marginBottom: '3%',
    cursor: 'pointer',
    borderRadius: 3
  },
  deleteButton: {
    backgroundSize: '700% 100%',
    transition: '0.2s ease',
    '&:hover': {
      color: '#e50d0d',
      // backgroundImage: 'linear-gradient(45deg, #cc0000, #e60000, #ff0000, #ff1a1a, #ff0000, #e60000, #cc0000)',
      boxShadow: 2,
      animation: 'redsw 300ms infinite'
    },
    "@keyframes redsw": {
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
  },
  editButton: {
    borderRadius: 3,
    ':hover': {
      boxShadow: 2,
      backgroundColor: '#80CB9E',
    }
  },
  buttonBox:{
    display: 'flex',
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between'
  },
  buttonComponent: {
    marginRight: "2%",
    backgroundColor: '#B9F5D9',
    borderRadius: 3,
    ':hover': {
      boxShadow: 2,
      backgroundColor: '#80CB9E',
    }
  },
  reactionButtons: {
    color: '#316C44',
    marginBottom: "5%",
  },
  selected: {
    marginRight: "2%",
    boxShadow: 2,
    backgroundColor: '#80CB9E',
    borderRadius: 3,
  },
  likeCount: {
    color: '#1D1E18',
    marginRight: "5%",
    fontFamily: 'Segoe UI semibold'
  },
  updated: {
    color: '#1D1E18',
    fontFamily: 'Segoe UI semibold'
    //textShadow: '1px 1px 2px gray'
  }
}