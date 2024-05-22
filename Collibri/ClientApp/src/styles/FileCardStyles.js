export const FileCardStyles = {
    card: {
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        height: '10rem',
        width: '20rem',
        boxShadow: 3,
        backgroundColor: '#d3ede1'
    },
    imageBox: {
        display: 'block',
        margin: 'auto',
        position: 'relative',
    },
    media: {
        width: '20rem',
        aspectRatio: 3,
        objectFit: 'contain',
        ':hover': {
            opacity: 0.8
        },
    },
    fileImage: {
        //color: 'green', cia bus galima pakeist pagal musu stiliu
        height: '6rem',
        width: '20rem',
    },
    content: {
        backgroundColor: "#93c4a7",
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'space-between',
        height: '4rem',
        width: '20rem'
    },
    nameBox: {
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'center',
        height: '100%',
        width: '74%',
    },
    fileName: {
        overflow: 'hidden',
        whiteSpace: 'nowrap',
        textOverflow: 'ellipsis'
    },
    buttons: {
        display: 'flex',
        flexDirection: 'row',
        alignItems: 'center',
        justifyContent: 'center',
        height: '100%',
        width: '20%',
        marginLeft: '1rem'
    }
}