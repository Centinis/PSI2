export const RoomListStyles = {
  roomContainer: {
    height: '87.7%',
    overflowY: 'scroll',
    '&::-webkit-scrollbar': {
      display: 'none'
    },
    scrollbarWidth: 'none',
    msOverflowStyle: 'none',
  },
  roomItemButton: {
    // backgroundColor: 'yellow',
    marginLeft: '0rem',
    height: '3.4rem',
    transitionDuration: '200ms',
    transitionProperty: 'margin-left, background, box-shadow',
    transitionTimingFunction: 'ease-out',
    
    '&:hover': {
      background: '#b0e7c8', //d6f5dd
      boxShadow: 7,
      marginLeft: '0.6rem',
      borderTopLeftRadius: '5px',
      borderBottomLeftRadius: '5px',
    },
    '&:focus': {
      bgcolor: '#d8f3e2',
      height: '3.4rem',
      marginLeft: '0.3rem',
      boxShadow: 5,
      borderTopLeftRadius: '5px',
      borderBottomLeftRadius: '5px',
      // borderStyle: 'solid',
      // borderColor: '#b2f8c4',
      // borderWidth: '0.125rem',
    }
  },
  roomClicked: {
    bgcolor: '#d8f3e2',
    marginLeft: '0.3rem',
    height: '3.4rem',
    boxShadow: 5,
    borderTopLeftRadius: '5px',
    borderBottomLeftRadius: '5px',
    // borderStyle: 'solid',
    // borderColor: '#7bc290',
    // borderWidth: '0.125rem',
  },
  roomClickedtext: {
    fontWeight: '800',
  },
}