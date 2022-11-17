import * as request from './requester.js';

const baseUrl = 'http://localhost:3030/data/pets';
const donationUrl = 'http://localhost:3030/data';

export const create = (data) => request.post(baseUrl, data);

export const getOne = (animalId) =>request.get(`${baseUrl}/${animalId}`); 

export const getAll = () => request.get(`${baseUrl}?sortBy=_createdOn%20desc&distinct=name`);

export const getCurrent = (animalId) => request.get(`${baseUrl}/${animalId}`);

export const edit =(animalId,data) => request.put(`${baseUrl}/${animalId}`,data);

export const remove = (animalId) => request.del(`${baseUrl}/${animalId}`);

export const getDonate = (animalId,userId) => 
    request.get(`${donationUrl}/donation?where=petId%3D%22${animalId}%22%20and%20_ownerId%3D%22${userId}%22&count`);

