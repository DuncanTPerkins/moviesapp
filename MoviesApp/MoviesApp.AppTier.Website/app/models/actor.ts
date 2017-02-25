import { Movie } from './movie';
import { ActorTag } from './actortag';

export class Actor{
    public ActorId: number;
    public Name: string;
    public Movies: Array<Movie>;
    public ActorTags: Array<ActorTag>;
    public Favorited: number;
}