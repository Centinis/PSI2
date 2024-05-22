import axios from 'axios';

export const fetchDocuments = async (postId, setDocuments) => {
  try {
    const response = await axios.get(`/v1/documents/${postId}`);
    setDocuments(response.data);
  } catch (err) {
    console.log(err);
  }
}

export const deleteDocument = async (documentId) => {
  try {
    const response = await axios.delete(`/v1/documents/${documentId}`);
    return response.data;
  } catch (err) {
    console.log(err);
  }
}

export const createDocument = async (postId, document) => {
    try {
        const response = await axios.post(`/v1/documents/${postId}`, JSON.parse(document), {
            headers: {
                'Content-Type': 'application/json',
            },
        });
    } catch (error) {
        if (error.response && error.response.status === 409) {
            console.error('Error creating Document: Document already exists.');
            throw new Error('Document already exists');
        } else {
            console.error('Error creating Document:', error.message);
            throw new Error('Failed to create Document');
        }
    }
};

export const deleteAllDocumentsInPost = (postId) => {
  fetch(`/v1/documents/in-post?postId=${postId}`, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
    }
  })
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to delete all documents in post.');
        }
      })
      .then(() => {
        console.log('All documents deleted successfully in post:', postId);
      })
      .catch(error => {
        console.error('Error deleting all documents:', error.message);
      });
}