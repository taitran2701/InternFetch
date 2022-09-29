import React, { useCallback, useEffect, useState } from "react";
import styles from "./index.module.scss";
import type { IPost } from "../Content";
import UpdatePost from "../modal/updatepostmodal";
import AddComment from "../AddComment";
import PostEmotion from "../PostEmotion";
import PostUser from "../PostUser";

interface IPostBodyProps {
  id: string;
  content: string;
  attachment: string;
  userId: any;
  upPost: any;
  post: IPost;
}
export default function PostBody(props: IPostBodyProps) {
  const { id, content, upPost, post, attachment } = props;
  const [show, setShow] = useState(false);
  const [posts, setPosts] = useState([]);
  const [reaction, setReaction] = useState<string>();
  const [count, setCount] = useState(0);
  const [color, setColor] = useState<string>();

  const [user, setUserName] = useState<{ userName: string }>();

  // Delete post
  const deletePost = (id: string) => {
    fetch(`https://localhost:7076/api/Posts?id=${id}`, {
      method: "DELETE",
    }).then((response) => {
      if (response.status === 200) {
        setPosts(
          posts.filter((post: IPost) => {
            return post.id !== id;
          })
        );
      } else {
        return;
      }
    });
  };

  //Get reaction with filter
  const upReaction = useCallback(() => {
    fetch(`https://localhost:7076/api/Reactions/filter?ID=${props.id}`, {
      headers: {
        "Content-type": "application/json;charset=UTF-8",
      },
    })
      .then((response) => response.json())
      .then((react) => {
        setReaction(react);
        console.log(react);

        let count = 0;
        let color = "";
        if (react.expression === "Like") {
          count += 1;
        }
        setCount(count);
        setColor(color);
        console.log(count);
      })
      .catch((err) => {
        console.log(err.message);
      });
  }, []);
  useEffect(() => {
    upReaction();
  }, [upReaction]);

  return (
    <React.Fragment>
      <PostUser />
      <div style={{ marginBottom: "20px" }}>
        {/* <div>{post.id} </div> */}
        <div className={styles.newsDescription}>{post.content}</div>
        <div className={styles.newsImage}>
          <img src={props.attachment} alt="" />
        </div>
        <div className={styles.newsEmotion}>
          <PostEmotion />
        </div>

        <div className={styles.feedAction}>
          <AddComment postComment={post} />
        </div>
        <div className={styles.deleteButton}>
          <button className="delete-btn" onClick={() => deletePost(post.id)}>
            Delete
          </button>
          <button onClick={() => setShow(true)} className="update-btn">
            Update
          </button>
          <UpdatePost
            show={show}
            onClose={() => setShow(false)}
            id={post.id}
            upPost={upPost}
            attachment={""}
          />
        </div>
      </div>
    </React.Fragment>
  );
}
