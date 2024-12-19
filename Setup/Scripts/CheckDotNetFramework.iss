function CheckForFramework(): Boolean;
begin
    Result := not IsDotNetInstalled(net481, 0);
end;

function UpdateReadyMemo(Space, NewLine, MemoUserInfoInfo, MemoDirInfo, MemoTypeInfo, MemoComponentsInfo, MemoGroupInfo, MemoTasksInfo: String): String;
var
	s: string;
begin
	s := MemoDirInfo;
  if ( MemoGroupInfo <> '' ) then
		s := s + NewLine + NewLine + MemoGroupInfo;
  if ( MemoTasksInfo <> '' ) then
		s := s + NewLine + NewLine + MemoTasksInfo;
  if ( CheckForFramework() ) then
  begin
		s := s + NewLine + NewLine + ExpandConstant('{cm:DotNetRequired_msg}');
  end;
	Result := s;
end;
