export const ManageTagsModalStyle = {
    modalWindow: {
        backgroundColor: '#B9F5D9',
        position: 'fixed',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: '33rem',
        height: '30rem',
        boxShadow: 24,
        p: 4,
        display: 'flex',
        border: '3px solid #000',
        borderColor: '#3f5c4b',
        borderRadius: 3,
    },
    
    controlBox: {
        //border: '2px solid #000',
        position: 'fixed',
        top: '0%',
        left: '0%',
        width: '60%',
        height: '100%',
    },
    
    addBox: {
        marginTop: '5%'
    },
    
    listBox: {
        borderLeft: '3px solid #000',
        borderColor: '#3f5c4b',
        position: 'fixed',
        top: '0%',
        left: '60%',
        width: '40%',
        height: '100%',
        backgroundColor: '#8ad0a6',
        borderTopRightRadius: 8,
        borderBottomRightRadius: 8
    },
    
    toBeDeleted: {
        display: 'flex',
        justifyContent: 'center',
        marginTop: '3%',
    },
    
    addButton: {
        backgroundColor: '#B9F5D9',
        color: '#3f5c4b',
        marginTop: '4%',
        '&:hover': {
            backgroundColor: '#B9F5D9',
            color: '#2f854c',
        },
    },
    
    deleteButtonNothingSelected: {
        backgroundColor: '#B9F5D9',
        color: '#3f5c4b',
        '&:hover': {
            backgroundColor: '#B9F5D9',
            color: '#6b6e6c',
        },
    },

    deleteButton: {
        backgroundColor: '#B9F5D9',
        color: '#3f5c4b',
        '&:hover': {
            backgroundColor: '#B9F5D9',
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
    },

    createTagLabel: {
        backgroundColor: '#97dab1'
    },

    deleteTagLabel: {
        marginTop: '10%',
        backgroundColor: '#97dab1'
    },
    
    textField: {
        marginTop: '3%',
        marginLeft: '5%',
        width: '76%',
        "& label.Mui-focused": {
            color: '#0d6925'
        },
        "& .MuiInput-underline:after": {
            borderColor: "#0d6925"
        }
    },
    
    tagList: {
        height: '99.6%',
        overflowY: 'auto',
        overflowX: 'hidden',
        '&::-webkit-scrollbar': {
           width: '10px'
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
        '&.Mui-selected': {
            backgroundColor: '#c0ffd6',
            ':hover': {
                backgroundColor: '#c0ffd6'
            }
        }
    }
}