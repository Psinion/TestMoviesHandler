const API_BASE_URL   = 'https://localhost:7268';

const ENDPOINTS = {
    API_FETCH_MOVIES:   'api/movies',
    API_POST_MOVIES:    'api/movies',
    API_FETCH_ACTORS:   'api/actors',
};

const Actions = {
    API_URL_FETCH_MOVIES:   `${API_BASE_URL}/${ENDPOINTS.API_FETCH_MOVIES}`,
    API_URL_POST_MOVIE:     `${API_BASE_URL}/${ENDPOINTS.API_POST_MOVIES}`,
    API_URL_FETCH_ACTORS:   `${API_BASE_URL}/${ENDPOINTS.API_FETCH_ACTORS}`,
};

export default Actions;