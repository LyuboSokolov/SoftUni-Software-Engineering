import * as request from './requester.js';

const baseUrl = 'http://localhost:3030/data/games';
const donationUrl = 'http://localhost:3030/data';

export const create = (data) => request.post(baseUrl, data);

export const getOne = (gameId) => request.get(`${baseUrl}/${gameId}`);

export const getAll = () => request.get(`${baseUrl}?sortBy=_createdOn%20desc`);

export const getMostGames = () => request.get(`${baseUrl}?sortBy=_createdOn%20desc&distinct=category`);

export const getCurrent = (gameId) => request.get(`${baseUrl}/${gameId}`);

export const edit = (gameId, data) => request.put(`${baseUrl}/${gameId}`, data);

export const remove = (gameId) => request.del(`${baseUrl}/${gameId}`);

export const getDonate = (animalId, userId) =>
    request.get(`${donationUrl}/donation?where=petId%3D%22${animalId}%22%20and%20_ownerId%3D%22${userId}%22&count`);

