function solution() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}
Content: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = super.toString();
            result += `\nRating: ${this.likes - this.dislikes}`;
            if (this.comments.length !== 0) {
                result += `\nComments:\n`;
                result += this.comments.map(e => ` * ${e}`).join('\n');
            }
            return result;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = Number(views);
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            let result = super.toString();
            result += `\nViews: ${this.views}`;
            return result;
        }
    }

    return {Post, SocialMediaPost, BlogPost};
}
let Post = solution().Post;
let SocialMediaPost = solution().SocialMediaPost;
let BlogPost = solution().BlogPost;

let post = new Post("Post", "Content");

console.log(post.toString());
console.log('this was post');

// Post: Post
// Content: Content

let scm = new SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!

let blog = new BlogPost('blog', 'content', 1);
blog.view();
blog.view();
blog.view().view().view();
console.log(blog.toString());
