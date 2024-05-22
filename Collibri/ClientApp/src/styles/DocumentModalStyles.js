export const DocumentModalStyles = {
    modal: {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: '45%',
        height: '90%',
        border: '2px solid #000',
        p: 2,
        bgcolor: '#DEFEF5',
        borderRadius: 2,
    },
    
    title: {
        minHeight: '4rem',
        maxHeight: '4rem',
        overflow: 'hidden',
        textAlign: 'center',
    },
    
    body: {
        whiteSpace: 'pre-wrap',
        marginLeft: '2%',
        marginRight: '2%',
        minHeight: '82%',
        maxHeight: '82%',
        wordBreak: 'break-word',
        overflowX: 'hidden',
        overflowY: 'auto',
        '&::-webkit-scrollbar': {
            height: '12px',
            marginLeft: '20px'
        },
        '&::-webkit-scrollbar-track': {
            backgroundColor: '#d3ede1',
            borderRadius: '20px',
        },
        '&::-webkit-scrollbar-thumb': {
            backgroundColor: '#80CB9E',
            border: 2,
            borderColor: '#d3ede1',
            borderRadius: '20px',
            boxShadow: 2,
        },
        '&::-webkit-scrollbar-thumb:hover': {
            backgroundColor: '#9be1b5'
        }
    },
    closeButton: {
        color: '#3f5c4b',
        backgroundColor: '#DEFEF5',
        ':hover': {
            color: '#138c37',
            backgroundColor: '#DEFEF5',
        }
    }
};