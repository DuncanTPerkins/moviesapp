import { Actor } from './actor';
import { MovieTag } from './movietag';

export class Movie{
    public Title: string;
    public Year: Date | null;
    public Rated: string;
    public Released: Date;
    public Genre: string;
    public Director: string;
    public Writer: string; 
    public Actors: Array<Actor>;
    public MovieTags: Array<MovieTag>;
    public Plot: string;
    public Language: string;
    public Country: string;
    public Awards: string;
    public Poster: string;
    public Metascore: number;
    public ImdbRating: string;
    public ImdbVotes: string;
    public ImdbId: string;
    public Type: string;
    public Response: string;
}