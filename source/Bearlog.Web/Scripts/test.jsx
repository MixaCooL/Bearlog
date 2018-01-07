var CommentBox = React.createClass({
    render: function () {
        return (
            <div className="commentBox">
                ReactJS greets you, stranger!
            </div>
        );
    }
});
ReactDOM.render(
    <CommentBox />,
    document.getElementById('content')
);