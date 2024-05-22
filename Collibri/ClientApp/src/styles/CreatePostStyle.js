export const CreatePostStyle = {
    modalWindow: {
        backgroundColor: '#eee',
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        border: '2px solid #000',
        p: 2,
        bgcolor: '#DEFEF5',
        borderRadius: 2,
        borderColor: '#3f5c4b',
        display: 'flex',
        flexDirection: 'column'
    },
    
    textFieldBox: {
        ml: 'auto',
        mr: 'auto',
        display: 'flex'
    },
    
    addTagsBox: {
        display: 'flex',
    },
    
    tagList: {
        display: 'flex',
        overflowX: 'auto',
        width: '35rem',
        backgroundColor: '#b9dcd0',
        paddingY: 0,
        height: '3.5rem',
        borderRadius: 3,
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
        display: 'flex',
        padding: 1,
        width: 'auto'
    },
    
    nameTextField: {
        width: 500,
        mb: 2
    },
    
    warningNote: {
        ml: 'auto',
        mr: 'auto',
        mt: 2,
        mb: 2
    },
    
    tagMenuButton: {
        backgroundColor: '#DEFEF5',
        color: '#286949',
        ':hover': {
            color: '#33a66b',
            backgroundColor: '#DEFEF5',
        },
    },
    
    tagMenu: {
        transform: 'translate(5rem, 0)',
        '.MuiMenu-list': {
            backgroundColor: '#c2e7d8',
        }
    },
    
    descriptionTextField: {
        width: 600
    },
    
    button: {
        color: '#316C44',
        backgroundColor: '#B9F5D9',
        margin: '2%',
        borderRadius: 3,
    }
}