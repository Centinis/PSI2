export const RoomLayoutStyle = {
  grid: {
    bgcolor: '#ebf8f2',
    display: 'flex',
    height: '100vh',
    width: '100vw',
  },
  roomGrid: {
    height: '100%',
    width:'17%',
  },
  roomsDivider: {
    fontSize: '8px',
    color: '#3e8855',
  },
  dividerBox: {
    height: '3%',
    
  },
  roomDrawer: {
    width: '17%',
    height: '100%',
    flexShrink: 0,
    '& .MuiDrawer-paper': {
      width: '17%',
      height: '100%',
      backgroundColor: '#94c9ac',  //1e7537
      boxSizing: 'border-box',
    },
  },
  title: {
    color: '#314231', 
    fontFamily: 'Segoe UI semibold',
    fontSize: '32px',
  },
  titleBox: {
    // bgcolor: 'red',
    // width: '90%',
    display: 'flex',
    height: '9.3%',
    alignItems: 'center',
    justifyContent: 'center',
  },
  roomName: {
    color: '#465d4b',
    fontWeight: 'bold',
    fontSize: '28px',
  },
  sectionsContainer: {
    height: '76.5%', 
    overflowY: 'scroll',
    '&::-webkit-scrollbar': {
      display: 'none'
    },
    scrollbarWidth: 'none',
    msOverflowStyle: 'none',
  },
}

export const postContainerStyle = { 
  maxWidth: "43rem" 
}

export const RoomLayoutStyles = {
  addSettingsButtons: {
    display: 'flex',
    marginLeft: '1rem',
    width: '3rem',
    height: '3rem',
  }
}