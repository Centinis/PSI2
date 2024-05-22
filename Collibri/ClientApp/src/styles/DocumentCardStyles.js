export const DocumentCardStyles = {
  generalText: {
    lineHeight: '1.5rem',
    minWidth: '15rem',
    maxWidth: '15rem',
    wordBreak: 'break-all',
    overflow: 'hidden',
    display: '-webkit-box',
    WebkitBoxOrient: 'vertical',
  },

  title: {
    // backgroundColor: 'yellow',
    WebkitLineClamp: '1',
    marginBottom: '1rem'
  },

  contentBox: {
    minHeight: '6.4rem',
    display: 'flex',
  },

  content: {
    WebkitLineClamp: '3',
    lineHeight: '1.2rem',
    // backgroundColor: 'red',
  },

  card: {
    display: 'flex',
    flexDirection: 'row',
    minWidth: '20rem',
    maxWidth: '20rem',
    minHeight: '10rem',
    maxHeight: '10rem',
    boxShadow: 3,
    backgroundColor: '#d3ede1'
  }
}