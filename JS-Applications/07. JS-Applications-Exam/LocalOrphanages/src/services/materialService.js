import * as request from './requester.js';

const baseUrl = 'http://localhost:3030/data/posts';


export const create = (data) => request.post(baseUrl, data);

export const getOne = (materialId) => request.get(`${baseUrl}/${materialId}`);

export const getAll = () => request.get(`${baseUrl}?sortBy=_createdOn%20desc`);

export const getMyPosts = (userId) => request.get(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);

export const getCurrent = (materialId) => request.get(`${baseUrl}/${materialId}`);

export const edit = (materialId, data) => request.put(`${baseUrl}/${materialId}`, data);

export const remove = (materialId) => request.del(`${baseUrl}/${materialId}`);

