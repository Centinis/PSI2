const modalStyles = {
    container: {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: '18rem',
        height: '14rem',
        p: 2,
        bgcolor: '#DEFEF5',
        borderRadius: 3,
    },
    centered: {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
    },
    registerContainer: {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: '35rem',
        height: '21rem',
        p: 2,
        bgcolor: '#DEFEF5',
        borderRadius: 3,
    },
    topContainer: {
        padding: '0.15rem',
        display: 'flex',
        justifyContent: 'space-between',
        alignItems: 'center',
        position: 'relative'
    },
    inputField: {
        borderRadius: '8px',
        fontFamily: 'Segoe UI',
        width: '15rem'
    },
    closeButtonContainer: {
        position: 'absolute', 
        top: '-5px', 
        right: '0', 
        padding: '16px'
    },
    helperText: {
        fontSize: '12px',
        opacity: '0.6'
    },
    errorHelperText: {
        color: 'red',
        fontSize: '12px',
        fontFamily: 'Segoe UI'
    },
    helperTextBox: {
        minHeight: '1.2rem',
        fontFamily: 'Segoe UI'
    },
    processing: {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        height: '100%',
    },
    progressIndicator: {
        marginTop: '1.5rem'
    },
    closeRepeatContainer: {
        display: 'flex',
        marginTop: '1.5rem',
    },
    title: {
        paddingTop: '0.3rem',
        fontFamily: 'Segoe UI semibold',
        color: '#1D1E18',
    },
    button: {
        textTransform: 'none',
        backgroundColor: '#316C44',
        fontSize: '1rem',
        borderRadius: 28,
        width: '8rem',
        color: '#DEFEF5',
        fontFamily: 'Segoe UI Semibold',
        float: 'right',
    },
};

export default modalStyles;
