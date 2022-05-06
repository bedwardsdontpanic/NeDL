import { NgbRating } from 'bootstrap';

export interface Feedback {
    name: string;
    picklist: string;
    suggestions: string;
    comments: string;
    rating: NgbRating;
}


function Feedback(name, picklist, suggestions, comments, rating) {
    this.name = name;
    this.picklist = picklist;
    this.suggestions = suggestions;
    this.comments = comments;
    this.rating = rating;
}
