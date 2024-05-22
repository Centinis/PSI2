export const LoginContainerStyles = {
    container: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    header: {
        position: 'absolute',
        top: 0,
        left: 0,
        padding: '2vh',
        zIndex: 1,
    },
    loadingContainer: {
        position: 'absolute',
        padding: '20px',
        borderRadius: '10px',
        textAlign: 'center',
        minWidth: '30rem',
        minHeight: '31rem',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        backdropFilter: 'blur(10px)'
    },
    wrongData: {
        color: 'red',
        fontSize: '0.75rem'
    },
    formContainer: {
        padding: '5vh',
        borderRadius: '10px',
        textAlign: 'center',
        minHeight: '30vh',
        // position: 'relative',
        // zIndex: 0,
    },
    fieldContainer: {
        minHeight: '11rem'
    },
    typography: {
        //marginBottom: 50,
        color: 'rgba(29, 30, 24, 0.7)',
        fontFamily: 'Segoe UI Semibold'
    },
    input: {
        borderRadius: '8px',
        fontFamily: 'Segoe UI',
    },
    link: {
        textDecoration: 'none',
        color: '#316C44',
        fontWeight: 600,
        marginBottom: 20,
        fontFamily: 'Segoe UI',
    },
    button: {
        textTransform: 'none',
        backgroundColor: '#316C44',
        fontSize: '16px',
        borderRadius: 28,
        width: '8rem',
        color: '#DEFEF5',
        fontFamily: 'Segoe UI Semibold'
    },
};
