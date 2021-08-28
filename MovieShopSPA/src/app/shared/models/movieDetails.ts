export interface Cast {
    id: number;
    name: string;
    gender: string;
    tmdbUrl: string;
    character: string;
    profilePath: string;
}

export interface Movie {
    id: number;
    title: string;
    overview: string;
    tagline: string;
    budget: number;
    revenue: number;
    imdbUrl: string;
    tmdbUrl: string;
    posterUrl: string;
    backdropUrl: string;
    originalLanguage: string;
    releaseDate: Date;
    runTime: number;
    price: number;
    createdDate: Date;
    updatedDate: Date;
    updatedBy: string;
    createdBy: string;
    rating: number;
    casts: Cast[];
    genres: Genre[];
}

export interface Genre {
    id: number;
    name: string;
}
