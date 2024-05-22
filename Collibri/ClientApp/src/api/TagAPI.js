import axios from 'axios';

export const fetchTags = async (postId, setTags) => {
    try {
        const response = await axios.get(`/v1/tags/on-post?postId=${postId}`)
        console.log(response.data);
        setTags(response.data);
    } catch (err) {
        console.log(err.message);
    }
}

export const getRoomTags = async (roomId, setTags) => {
    try {
        const response = await axios.get(`/v1/tags/?roomId=${roomId}`)
        console.log(response.data);
        setTags(response.data);
    } catch (err) {
        console.log(err.message);
    }
}

// export const fetchTags = (postId, setTags) => {
//     fetch(`/v1/tags/on-post?postId=${postId}`, { 
//         method: "GET",
//         headers: {
//             'Content-Type': 'application/json',
//         }, 
//     })
//         .then((response) => response.json())
//         .then((data) => {
//             console.log(data);
//             setTags(data);
//         })
//         .catch(error => console.error('Error fetching data', error));
// }

export const createTag = (tag, setTags) => {
    fetch(`/v1/tags`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: tag
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to create tag');
            }
            return response.json();
        })
        .then((data) => {
            console.log('Tag created successfully: ', data);
            setTags(prevTags => [...prevTags, data]);
        })
        .catch(error => {
            console.error('Error creating tag:', error.message);
        });
}

export const deleteTag = (tagId, setTags) => {
    fetch(`/v1/tags?tagId=${tagId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to delete tag');
            }
            return response.json();
        })
        .then((data) => {
            console.log('Tag deleted successfully: ', data);
            setTags(prevTags => prevTags.filter(tag => tag.id !== tagId));
        })
        .catch(error => {
            console.error('Error deleting tag:', error.message);
        });
}

export const addToPost = (tagId, postId) => {
    fetch(`/v1/post-tags?tagId=${tagId}&postId=${postId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to add tag');
            }
        })
        .then(() => {
            console.log('Tag added successfully');
        })
        .catch(error => {
            console.error('Error adding tag:', error.message);
        });
}