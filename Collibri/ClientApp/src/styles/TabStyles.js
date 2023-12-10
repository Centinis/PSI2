import {aboutTab} from "../components/AboutPage";

const tabStyles = {
    background: {
        marginTop: '3rem' ,
        marginLeft: '25%', 
        backgroundColor: '#DEFEF5', 
        borderRadius: 3
    },
    aboutTabBackground: {
        marginTop: '3rem' ,
        backgroundColor: '#DEFEF5',
        borderRadius: 3
    },
    mainTabs: {
        paddingLeft: '10%',
        paddingRight: '10%',
        fontFamily: 'Segoe UI',
        
        // maxWidth: '40%'
    },
    question: {
        paddingBottom: '1.2rem',
        fontWeight: 'bold'
    },
    answer:{
        paddingBottom: '0.6rem',
    },
    reviews:{
        overflowX: 'auto',
        whiteSpace: 'nowrap',
    },
    comments:{
        paddingTop: '0.6rem', 
        paddingLeft: '1rem',
        fontSize : '1.5rem',
        fontFamily: 'Segoe UI',
        marginLeft: '1rem',
        whiteSpace: 'normal', // Updated property for text wrapping
    },
    commentBox:{
        paddingBottom: '1.5rem',
        display: 'inline-block',
        verticalAlign: 'top',
        padding: '1rem',
        marginRight: '1rem',
        backgroundColor: '#B9F5D9',
        border: '1px solid #80CB9E',
        borderRadius: 3,
        width: '30rem',
        height: '20rem'
    },
    questionBox: {
        height:'auto',
        backgroundColor: '#B9F5D9', 
        borderRadius: '10px', 
        border: '1px solid #80CB9E', 
        padding: '1rem', 
        marginBottom: '0.5rem'
    }
};
export default tabStyles;