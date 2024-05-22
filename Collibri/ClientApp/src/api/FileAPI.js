import axios from 'axios';

export const fetchFiles = async (postId, setFiles) => {
    try {
        const response = await axios.get(`/v1/files/info/${postId}`);
        setFiles(response.data);
    } catch (error) {
        console.log(error.message);
    }
}

export const uploadFile = async (postId, formData, setFiles) => {
    try {
        const response = await axios.post(`/v1/files/${postId}`, formData);
        setFiles((prevFiles) => [...prevFiles, response.data]);
    } catch (error) {
        console.log(error.message);
    }
}

export const getFile = async (id) => {
    const response = await fetch(`/v1/files/data/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },
        responseType: 'blob'
    });
    if (!response.ok) {
        throw new Error("Failed to get file data");
    }

    return await response.blob();
}

export const deleteFile = async (id) => {
    try {
        const response = await axios.delete(`/v1/files/${id}`);
    } catch (error) {
        console.log(error.message);
    }
}