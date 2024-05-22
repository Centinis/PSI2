export const editButtonStyle = {
    color: '#81a989',
}

export const deleteButtonStyle = {
    color: '#81a989',
    '&:hover': {
        animationDuration: '300ms',
        animationName: 'redsw',
        animationIterationCount: 'infinite',
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
}

export const nameCellStyle = {
    cursor: 'pointer',
    color: '#5e7c65',
    fontWeight: '700',
}

export const SectionsContainerStyles = {
    tableBody: {
        '&:last-child td, &:last-child th': { border: 0 },
        height: '5rem',
        border: '10px',
        '&:hover': {
            background: '#e2f1ea',
            boxShadow: 3,
        },
    },
    sectionSelected: {
        background: '#ebf8f2',
        boxShadow: 2,
        height: '5rem',
    },
    emptySectionsBox: {
        marginTop: '55%',
        display: 'flex',
        height: '78.5%',
        justifyContent: 'center',
        alignItems: 'center',
    },
    noSectionsMessage: {
        color: '#81a989',
        fontFamily: 'Segoe UI semibold',
    },
    
}